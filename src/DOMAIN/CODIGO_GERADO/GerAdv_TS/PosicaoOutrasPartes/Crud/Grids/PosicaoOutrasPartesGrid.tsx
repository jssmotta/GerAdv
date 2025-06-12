//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PosicaoOutrasPartesEmpty } from '../../../Models/PosicaoOutrasPartes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPosicaoOutrasPartes } from '../../Interfaces/interface.PosicaoOutrasPartes';
import { PosicaoOutrasPartesService } from '../../Services/PosicaoOutrasPartes.service';
import { PosicaoOutrasPartesApi } from '../../Apis/ApiPosicaoOutrasPartes';
import { PosicaoOutrasPartesGridMobileComponent } from '../GridsMobile/PosicaoOutrasPartes';
import { PosicaoOutrasPartesGridDesktopComponent } from '../GridsDesktop/PosicaoOutrasPartes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPosicaoOutrasPartes } from '../../Filters/PosicaoOutrasPartes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PosicaoOutrasPartesWindow from './PosicaoOutrasPartesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePosicaoOutrasPartesList } from '../../Hooks/hookPosicaoOutrasPartes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PosicaoOutrasPartesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const posicaooutraspartesService = useMemo(() => {
    return new PosicaoOutrasPartesService(
    new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: posicaooutraspartes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePosicaoOutrasPartesList(posicaooutraspartesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPosicaoOutrasPartes, setSelectedPosicaoOutrasPartes] = useState<IPosicaoOutrasPartes>(PosicaoOutrasPartesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPosicaoOutrasPartes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPosicaoOutrasPartes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPosicaoOutrasPartes);
};
// Handlers para o grid
const handleRowClick = (posicaooutraspartes: IPosicaoOutrasPartes) => {
  setSelectedPosicaoOutrasPartes(posicaooutraspartes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPosicaoOutrasPartes(PosicaoOutrasPartesEmpty());
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
  const posicaooutraspartes = e.dataItem;
  setDeleteId(posicaooutraspartes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await posicaooutraspartesService.deletePosicaoOutrasPartes(deleteId);
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
    <PosicaoOutrasPartesGridMobileComponent
    data={posicaooutraspartes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PosicaoOutrasPartesGridDesktopComponent
    data={posicaooutraspartes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PosicaoOutrasPartesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPosicaoOutrasPartes={selectedPosicaoOutrasPartes}
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
export default PosicaoOutrasPartesGrid;