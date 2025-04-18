﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { DocumentosApi } from '../../Apis/ApiDocumentos';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IDocumentosFormProps } from '../../Interfaces/interface.Documentos';
import { DocumentosService } from '../../Services/Documentos.service';
import { useDocumentosForm } from '../../Hooks/useDocumentosForm';
import { DocumentosEmpty } from '../../../Models/Documentos'; 
import { DocumentosForm } from '../Forms/Documentos';
 
const DocumentosInc: React.FC<IDocumentosFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const documentosService = new DocumentosService(
    new DocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadDocumentos } = useDocumentosForm(
    DocumentosEmpty(),
    documentosService
  );

  useEffect(() => {
    loadDocumentos(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedDocumentos = await documentosService.saveDocumentos(data);

      if (savedDocumentos.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/documentos');
          return;
        }

        if (onSuccess) {
          onSuccess();
        }
      } else {
         if (onError) {
          onError();
        }
        notificationService.showNotification('Error salvando registro.', 'error');
      }
    } catch (error) {
        if (onError) {
          onError();
        }
      notificationService.showNotification('Error salvando registro.', 'error');
    }
  };

  return (
    <>
      <NotificationComponent notificationService={notificationService} />
      <DocumentosForm
        documentosData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default DocumentosInc;
