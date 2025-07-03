//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AlertasEmpty } from '../../../Models/Alertas';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAlertas } from '../../Interfaces/interface.Alertas';
import { AlertasService } from '../../Services/Alertas.service';
import { AlertasApi } from '../../Apis/ApiAlertas';
import { AlertasGridMobileComponent } from '../GridsMobile/Alertas';
import { AlertasGridDesktopComponent } from '../GridsDesktop/Alertas';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAlertas } from '../../Filters/Alertas';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AlertasWindow from './AlertasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAlertasList } from '../../Hooks/hookAlertas';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AlertasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const alertasService = useMemo(() => {
    return new AlertasService(
    new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: alertas, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAlertasList(alertasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAlertas, setSelectedAlertas] = useState<IAlertas>(AlertasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAlertas | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAlertas | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAlertas);
};
// Handlers para o grid
const handleRowClick = (alertas: IAlertas) => {
  setSelectedAlertas(alertas);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAlertas(AlertasEmpty());
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
  const alertas = e.dataItem;
  setDeleteId(alertas.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await alertasService.deleteAlertas(deleteId);
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
    <AlertasGridMobileComponent
    data={alertas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AlertasGridDesktopComponent
    data={alertas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AlertasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAlertas={selectedAlertas}
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
export default AlertasGrid;