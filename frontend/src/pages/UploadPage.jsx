import React, { useState } from 'react';
import axios from 'axios';

function UploadPage() {
  const [file, setFile] = useState(null);
  const [preview, setPreview] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [analysis, setAnalysis] = useState(null);
  const [error, setError] = useState(null);

  const handleFileChange = (e) => {
    const selectedFile = e.target.files[0];
    if (selectedFile) {
      setFile(selectedFile);
      setPreview(URL.createObjectURL(selectedFile));
      setAnalysis(null);
      setError(null);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!file) return;

    setIsLoading(true);
    setError(null);

    try {
      const formData = new FormData();
      formData.append('image', file);

      const response = await axios.post('/api/analyze', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      setAnalysis(response.data);
    } catch (err) {
      setError(err.response?.data?.message || 'Failed to analyze image');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '800px', margin: '2rem auto', padding: '1rem' }}>
      <h1>Upload Coffee Grind Image</h1>
      <p>Upload an image of your coffee grind for analysis.</p>

      <form onSubmit={handleSubmit} style={{ marginBottom: '1rem' }}>
        <input type="file" accept="image/*" onChange={handleFileChange} required />
        <button type="submit" disabled={!file || isLoading} style={{ marginLeft: '1rem' }}>
          {isLoading ? 'Analyzing...' : 'Analyze'}
        </button>
      </form>

      {preview && (
        <div style={{ marginBottom: '1rem' }}>
          <h3>Preview:</h3>
          <img src={preview} alt="Preview" style={{ maxWidth: '100%', maxHeight: '400px' }} />
        </div>
      )}

      {error && <p style={{ color: 'red' }}>Error: {error}</p>}

      {analysis && (
        <div style={{ marginTop: '1rem', padding: '1rem', background: '#f0f0f0', borderRadius: '4px' }}>
          <h3>Analysis Results:</h3>
          <pre>{JSON.stringify(analysis, null, 2)}</pre>
        </div>
      )}
    </div>
  );
}

export default UploadPage;
