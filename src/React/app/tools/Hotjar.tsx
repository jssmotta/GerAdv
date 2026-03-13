'use client';
import React, { useEffect } from 'react';
import Hotjar from '@hotjar/browser';

const HotjarComponent: React.FC = () => {
  useEffect(() => {
    try {
      const siteId = Number(process.env.NEXT_PUBLIC_HOTJAR ?? '0');
      if (siteId > 0) {
        const hotjarVersion = 6;
        Hotjar.init(siteId, hotjarVersion);
      }
    } catch (error) {
      // Silently ignore Hotjar errors (common with ad blockers)
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.warn('Hotjar initialization failed:', error);
      }
    }
  }, []);

  return null;
};

export default HotjarComponent;
