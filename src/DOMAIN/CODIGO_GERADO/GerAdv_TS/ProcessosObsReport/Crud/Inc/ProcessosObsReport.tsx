﻿"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { ProcessosObsReportApi } from '../../Apis/ApiProcessosObsReport';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IProcessosObsReportFormProps } from '../../Interfaces/interface.ProcessosObsReport';
import { ProcessosObsReportService } from '../../Services/ProcessosObsReport.service';
import { useProcessosObsReportForm } from '../../Hooks/useProcessosObsReportForm';
import { ProcessosObsReportEmpty } from '../../../Models/ProcessosObsReport'; 
import { ProcessosObsReportForm } from '../Forms/ProcessosObsReport';
 
const ProcessosObsReportInc: React.FC<IProcessosObsReportFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const processosobsreportService = new ProcessosObsReportService(
    new ProcessosObsReportApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadProcessosObsReport } = useProcessosObsReportForm(
    ProcessosObsReportEmpty(),
    processosobsreportService
  );

  useEffect(() => {
    loadProcessosObsReport(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedProcessosObsReport = await processosobsreportService.saveProcessosObsReport(data);

      if (savedProcessosObsReport.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/processosobsreport');
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
      <ProcessosObsReportForm
        processosobsreportData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default ProcessosObsReportInc;
