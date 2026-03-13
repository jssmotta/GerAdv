'use client';

import React, { useEffect, useState } from 'react';

interface ClientOnlyStyleProps {
  css: string;
}

const ClientOnlyStyle: React.FC<ClientOnlyStyleProps> = ({ css }) => {
  const [isMounted, setIsMounted] = useState(false);

  useEffect(() => {
    setIsMounted(true);
  }, []);

  if (!isMounted) {
    return null;
  }

  return <style>{css}</style>;
};

export default ClientOnlyStyle;
