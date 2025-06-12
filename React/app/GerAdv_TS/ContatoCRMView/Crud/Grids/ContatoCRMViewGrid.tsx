//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ContatoCRMViewEmpty } from '../../../Models/ContatoCRMView';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IContatoCRMView } from '../../Interfaces/interface.ContatoCRMView';
import { ContatoCRMViewService } from '../../Services/ContatoCRMView.service';
import { ContatoCRMViewApi } from '../../Apis/ApiContatoCRMView';
import { ContatoCRMViewGridMobileComponent } from '../GridsMobile/ContatoCRMView';
import { ContatoCRMViewGridDesktopComponent } from '../GridsDesktop/ContatoCRMView';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterContatoCRMView } from '../../Filters/ContatoCRMView';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ContatoCRMViewWindow from './ContatoCRMViewWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useContatoCRMViewList } from '../../Hooks/hookContatoCRMView';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ContatoCRMViewGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const contatocrmviewService = useMemo(() => {
    return new ContatoCRMViewService(
    new ContatoCRMViewApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: contatocrmview, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useContatoCRMViewList(contatocrmviewService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedContatoCRMView, setSelectedContatoCRMView] = useState<IContatoCRMView>(ContatoCRMViewEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterContatoCRMView | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterContatoCRMView | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterContatoCRMView);
};
// Handlers para o grid
const handleRowClick = (contatocrmview: IContatoCRMView) => {
  setSelectedContatoCRMView(contatocrmview);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedContatoCRMView(ContatoCRMViewEmpty());
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
  const contatocrmview = e.dataItem;
  setDeleteId(contatocrmview.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await contatocrmviewService.deleteContatoCRMView(deleteId);
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
    <ContatoCRMViewGridMobileComponent
    data={contatocrmview}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ContatoCRMViewGridDesktopComponent
    data={contatocrmview}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ContatoCRMViewWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedContatoCRMView={selectedContatoCRMView}
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
export default ContatoCRMViewGrid;