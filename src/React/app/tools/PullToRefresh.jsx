import React, { useState } from 'react';
import { SvgIcon } from '@progress/kendo-react-common';

const ArrowDownCircle = () => (
  <SvgIcon viewBox="0 0 24 24">
    <path d="M12,2C6.48,2,2,6.48,2,12s4.48,10,10,10s10-4.48,10-10S17.52,2,12,2z M12,17c-1.66,0-3-1.34-3-3s1.34-3,3-3s3,1.34,3,3S13.66,17,12,17z" />
  </SvgIcon>
);

const PullToRefresh = () => {
  const [startY, setStartY] = useState(0);
  const [pulling, setPulling] = useState(false);
  const [loading, setLoading] = useState(false);
  const [pullDistance, setPullDistance] = useState(0);
  
  const handleTouchStart = (e) => {
    // Only enable pull to refresh when at top of page
    if (window.scrollY === 0) {
      setStartY(e.touches[0].clientY);
      setPulling(true);
    }
  };

  const handleTouchMove = (e) => {
    if (!pulling) return;
    
    const currentY = e.touches[0].clientY;
    const distance = currentY - startY;
    
    // Only allow pulling down
    if (distance > 0) {
      setPullDistance(Math.min(distance, 100)); // Max pull distance of 100px
      e.preventDefault();
    }
  };

  const handleTouchEnd = async () => {
    if (!pulling) return;
    
    setPulling(false);
    
    // If pulled far enough, trigger refresh
    if (pullDistance > 60) {
      setLoading(true);
      
      // Simulate loading
      await new Promise(resolve => setTimeout(resolve, 1500));
      
      // Reload page
      window.location.reload();
    }
    
    setPullDistance(0);
  };

  return (
    <div 
      className="relative w-full min-h-screen bg-gray-100"
      onTouchStart={handleTouchStart}
      onTouchMove={handleTouchMove}
      onTouchEnd={handleTouchEnd}
    >
      {/* Pull indicator */}
      {pullDistance > 0 && (
        <div 
          className="fixed top-0 left-0 w-full flex justify-center items-center transition-transform duration-200"
          style={{
            transform: `translateY(${pullDistance}px)`,
            opacity: Math.min(pullDistance / 60, 1)
          }}
        >
          <div className="bg-white rounded-full shadow p-2">
            <ArrowDownCircle 
              className={`w-6 h-6 transition-transform duration-200 ${loading ? 'animate-spin' : ''}`}
              style={{
                transform: `rotate(${Math.min((pullDistance / 60) * 180, 180)}deg)`
              }}
            />
          </div>
        </div>
      )}
    </div>
  );
};

export default PullToRefresh;