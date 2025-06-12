//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProObservacoesEmpty } from '../../../Models/ProObservacoes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProObservacoes } from '../../Interfaces/interface.ProObservacoes';
import { ProObservacoesService } from '../../Services/ProObservacoes.service';
import { ProObservacoesApi } from '../../Apis/ApiProObservacoes';
import { ProObservacoesGridMobileComponent } from '../GridsMobile/ProObservacoes';
import { ProObservacoesGridDesktopComponent } from '../GridsDesktop/ProObservacoes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProObservacoes } from '../../Filters/ProObservacoes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProObservacoesWindow from './ProObservacoesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProObservacoesList } from '../../Hooks/hookProObservacoes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProObservacoesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const proobservacoesService = useMemo(() => {
    return new ProObservacoesService(
    new ProObservacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: proobservacoes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProObservacoesList(proobservacoesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProObservacoes, setSelectedProObservacoes] = useState<IProObservacoes>(ProObservacoesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProObservacoes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProObservacoes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProObservacoes);
};
// Handlers para o grid
const handleRowClick = (proobservacoes: IProObservacoes) => {
  setSelectedProObservacoes(proobservacoes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProObservacoes(ProObservacoesEmpty());
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
  const proobservacoes = e.dataItem;
  setDeleteId(proobservacoes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await proobservacoesService.deleteProObservacoes(deleteId);
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
    <ProObservacoesGridMobileComponent
    data={proobservacoes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProObservacoesGridDesktopComponent
    data={proobservacoes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProObservacoesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProObservacoes={selectedProObservacoes}
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
export default ProObservacoesGrid;