"use client";

import { useState, useCallback } from 'react';
import { getWindowContent } from '@/app/utils/copyCurrentWindow';

export const useCopyWindowDialog = () => {
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const [dialogContent, setDialogContent] = useState('');

  const showCopyDialog = useCallback((formId: string, printHeaderFooter: boolean = false) => {
    const content = getWindowContent(formId, printHeaderFooter);
    if (content) {
      setDialogContent(content);
      setIsDialogOpen(true);
    } else {
      alert('Não foi possível obter o conteúdo da janela.');
    }
  }, []);

  const closeDialog = useCallback(() => {
    setIsDialogOpen(false);
    setDialogContent('');
  }, []);

  return {
    isDialogOpen,
    dialogContent,
    showCopyDialog,
    closeDialog
  };
};
