//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TerceirosEmpty } from '../../../Models/Terceiros';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITerceiros } from '../../Interfaces/interface.Terceiros';
import { TerceirosService } from '../../Services/Terceiros.service';
import { TerceirosApi } from '../../Apis/ApiTerceiros';
import { TerceirosGridMobileComponent } from '../GridsMobile/Terceiros';
import { TerceirosGridDesktopComponent } from '../GridsDesktop/Terceiros';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTerceiros } from '../../Filters/Terceiros';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TerceirosWindow from './TerceirosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTerceirosList } from '../../Hooks/hookTerceiros';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TerceirosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const terceirosService = useMemo(() => {
    return new TerceirosService(
    new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: terceiros, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTerceirosList(terceirosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTerceiros, setSelectedTerceiros] = useState<ITerceiros>(TerceirosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTerceiros | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTerceiros | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTerceiros);
};
// Handlers para o grid
const handleRowClick = (terceiros: ITerceiros) => {
  setSelectedTerceiros(terceiros);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTerceiros(TerceirosEmpty());
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
  const terceiros = e.dataItem;
  setDeleteId(terceiros.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await terceirosService.deleteTerceiros(deleteId);
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
    <TerceirosGridMobileComponent
    data={terceiros}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TerceirosGridDesktopComponent
    data={terceiros}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TerceirosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTerceiros={selectedTerceiros}
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
export default TerceirosGrid;