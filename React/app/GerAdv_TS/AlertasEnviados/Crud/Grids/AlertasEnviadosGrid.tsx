//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AlertasEnviadosEmpty } from '../../../Models/AlertasEnviados';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAlertasEnviados } from '../../Interfaces/interface.AlertasEnviados';
import { AlertasEnviadosService } from '../../Services/AlertasEnviados.service';
import { AlertasEnviadosApi } from '../../Apis/ApiAlertasEnviados';
import { AlertasEnviadosGridMobileComponent } from '../GridsMobile/AlertasEnviados';
import { AlertasEnviadosGridDesktopComponent } from '../GridsDesktop/AlertasEnviados';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAlertasEnviados } from '../../Filters/AlertasEnviados';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AlertasEnviadosWindow from './AlertasEnviadosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAlertasEnviadosList } from '../../Hooks/hookAlertasEnviados';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AlertasEnviadosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const alertasenviadosService = useMemo(() => {
    return new AlertasEnviadosService(
    new AlertasEnviadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: alertasenviados, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAlertasEnviadosList(alertasenviadosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAlertasEnviados, setSelectedAlertasEnviados] = useState<IAlertasEnviados>(AlertasEnviadosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAlertasEnviados | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAlertasEnviados | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAlertasEnviados);
};
// Handlers para o grid
const handleRowClick = (alertasenviados: IAlertasEnviados) => {
  setSelectedAlertasEnviados(alertasenviados);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAlertasEnviados(AlertasEnviadosEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const alertasenviados = e.dataItem;
  setDeleteId(alertasenviados.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await alertasenviadosService.deleteAlertasEnviados(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <AlertasEnviadosGridMobileComponent
    data={alertasenviados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AlertasEnviadosGridDesktopComponent
    data={alertasenviados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AlertasEnviadosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAlertasEnviados={selectedAlertasEnviados}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default AlertasEnviadosGrid;