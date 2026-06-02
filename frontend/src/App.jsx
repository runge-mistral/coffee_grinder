import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import UploadPage from './pages/UploadPage';
import ComparePage from './pages/ComparePage';

function App() {
  return (
    <Router>
      <nav style={{ padding: '1rem', background: '#333', color: 'white' }}>
        <Link to="/" style={{ color: 'white', marginRight: '1rem' }}>Home</Link>
        <Link to="/upload" style={{ color: 'white', marginRight: '1rem' }}>Upload</Link>
        <Link to="/compare" style={{ color: 'white' }}>Compare</Link>
      </nav>
      
      <Routes>
        <Route path="/" element={<h1 style={{ textAlign: 'center', marginTop: '2rem' }}>Coffee Grinder Comparison</h1>} />
        <Route path="/upload" element={<UploadPage />} />
        <Route path="/compare" element={<ComparePage />} />
      </Routes>
    </Router>
  );
}

export default App;
