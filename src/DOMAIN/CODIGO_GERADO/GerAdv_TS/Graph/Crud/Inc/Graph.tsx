"use client";
import React, { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { GraphApi } from '../../Apis/ApiGraph';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NotificationService } from '@/app/services/notification.service';
import { NotificationComponent } from '@/app/components/NotificationComponent';
import { IGraphFormProps } from '../../Interfaces/interface.Graph';
import { GraphService } from '../../Services/Graph.service';
import { useGraphForm } from '../../Hooks/useGraphForm';
import { GraphEmpty } from '../../../Models/Graph'; 
import { GraphForm } from '../Forms/Graph';
 
const GraphInc: React.FC<IGraphFormProps> = ({ id, onClose, onError, onSuccess }) => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const router = useRouter();

  const graphService = new GraphService(
    new GraphApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
  const notificationService = new NotificationService();

  const { data, handleChange, loadGraph } = useGraphForm(
    GraphEmpty(),
    graphService
  );

  useEffect(() => {
    loadGraph(id);
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const savedGraph = await graphService.saveGraph(data);

      if (savedGraph.id) {
        notificationService.showNotification('Registro salvo com sucesso!', 'success');

        if (isMobile) {
          router.push('/pages/graph');
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
      <GraphForm
        graphData={data}
        onChange={handleChange}
        onSubmit={handleSubmit}
        onClose={onClose}
        onError={onError}
      />
    </>
  );
};

export default GraphInc;
