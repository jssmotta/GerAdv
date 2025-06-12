//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PenhoraEmpty } from '../../../Models/Penhora';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPenhora } from '../../Interfaces/interface.Penhora';
import { PenhoraService } from '../../Services/Penhora.service';
import { PenhoraApi } from '../../Apis/ApiPenhora';
import { PenhoraGridMobileComponent } from '../GridsMobile/Penhora';
import { PenhoraGridDesktopComponent } from '../GridsDesktop/Penhora';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPenhora } from '../../Filters/Penhora';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PenhoraWindow from './PenhoraWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePenhoraList } from '../../Hooks/hookPenhora';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PenhoraGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const penhoraService = useMemo(() => {
    return new PenhoraService(
    new PenhoraApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: penhora, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePenhoraList(penhoraService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPenhora, setSelectedPenhora] = useState<IPenhora>(PenhoraEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPenhora | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPenhora | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPenhora);
};
// Handlers para o grid
const handleRowClick = (penhora: IPenhora) => {
  setSelectedPenhora(penhora);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPenhora(PenhoraEmpty());
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
  const penhora = e.dataItem;
  setDeleteId(penhora.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await penhoraService.deletePenhora(deleteId);
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
    <PenhoraGridMobileComponent
    data={penhora}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PenhoraGridDesktopComponent
    data={penhora}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PenhoraWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPenhora={selectedPenhora}
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
export default PenhoraGrid;