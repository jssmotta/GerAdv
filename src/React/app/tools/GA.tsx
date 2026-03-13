"use client";
import { useEffect } from 'react';
import ReactGA from 'react-ga4';

const GAComponent: React.FC = () => {
  useEffect(() => {
    try {
      const gaId = process.env.NEXT_PUBLIC_GA;
      if (gaId) {
        ReactGA.initialize(gaId);
        ReactGA.send({
          hitType: 'pageview',
          page: window.location.pathname + window.location.search,
        });
      }
    } catch (error) {
      // Silently ignore analytics errors (common with ad blockers)
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.warn('Google Analytics initialization failed:', error);
      }
    }
  }, []);

  return null;
};

export default GAComponent;
