//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ContatoCRMEmpty } from '../../../Models/ContatoCRM';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IContatoCRM } from '../../Interfaces/interface.ContatoCRM';
import { ContatoCRMService } from '../../Services/ContatoCRM.service';
import { ContatoCRMApi } from '../../Apis/ApiContatoCRM';
import { ContatoCRMGridMobileComponent } from '../GridsMobile/ContatoCRM';
import { ContatoCRMGridDesktopComponent } from '../GridsDesktop/ContatoCRM';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterContatoCRM } from '../../Filters/ContatoCRM';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ContatoCRMWindow from './ContatoCRMWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useContatoCRMList } from '../../Hooks/hookContatoCRM';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ContatoCRMGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const contatocrmService = useMemo(() => {
    return new ContatoCRMService(
    new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: contatocrm, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useContatoCRMList(contatocrmService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedContatoCRM, setSelectedContatoCRM] = useState<IContatoCRM>(ContatoCRMEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterContatoCRM | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterContatoCRM | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterContatoCRM);
};
// Handlers para o grid
const handleRowClick = (contatocrm: IContatoCRM) => {
  setSelectedContatoCRM(contatocrm);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedContatoCRM(ContatoCRMEmpty());
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
  const contatocrm = e.dataItem;
  setDeleteId(contatocrm.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await contatocrmService.deleteContatoCRM(deleteId);
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
    <ContatoCRMGridMobileComponent
    data={contatocrm}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ContatoCRMGridDesktopComponent
    data={contatocrm}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ContatoCRMWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedContatoCRM={selectedContatoCRM}
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
export default ContatoCRMGrid;