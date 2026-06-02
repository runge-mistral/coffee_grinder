import React, { useState, useEffect } from 'react';
import axios from 'axios';

function ComparePage() {
  const [uploads, setUploads] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUploads = async () => {
      try {
        const response = await axios.get('/api/uploads');
        setUploads(response.data);
      } catch (err) {
        setError(err.response?.data?.message || 'Failed to fetch uploads');
      } finally {
        setIsLoading(false);
      }
    };

    fetchUploads();
  }, []);

  return (
    <div style={{ maxWidth: '800px', margin: '2rem auto', padding: '1rem' }}>
      <h1>Compare Coffee Grinds</h1>
      <p>View and compare all uploaded coffee grind analyses.</p>

      {isLoading && <p>Loading...</p>}
      {error && <p style={{ color: 'red' }}>Error: {error}</p>}

      {!isLoading && !error && (
        <div>
          {uploads.length === 0 ? (
            <p>No uploads yet. Go to the Upload page to add some!</p>
          ) : (
            <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fill, minmax(250px, 1fr))', gap: '1rem' }}>
              {uploads.map((upload) => (
                <div key={upload.id} style={{ border: '1px solid #ccc', padding: '1rem', borderRadius: '4px' }}>
                  <h3>{upload.name || `Upload #${upload.id}`}</h3>
                  {upload.imageUrl && (
                    <img src={upload.imageUrl} alt="Coffee grind" style={{ maxWidth: '100%', height: 'auto' }} />
                  )}
                  <p><strong>Grind Size:</strong> {upload.grindSize || 'N/A'}</p>
                  <p><strong>Consistency:</strong> {upload.consistency || 'N/A'}</p>
                  <p><small>{new Date(upload.createdAt).toLocaleString()}</small></p>
                </div>
              ))}
            </div>
          )}
        </div>
      )}
    </div>
  );
}

export default ComparePage;
