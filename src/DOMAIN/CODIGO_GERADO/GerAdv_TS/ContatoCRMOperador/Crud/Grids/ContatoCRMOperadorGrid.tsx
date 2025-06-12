//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ContatoCRMOperadorEmpty } from '../../../Models/ContatoCRMOperador';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IContatoCRMOperador } from '../../Interfaces/interface.ContatoCRMOperador';
import { ContatoCRMOperadorService } from '../../Services/ContatoCRMOperador.service';
import { ContatoCRMOperadorApi } from '../../Apis/ApiContatoCRMOperador';
import { ContatoCRMOperadorGridMobileComponent } from '../GridsMobile/ContatoCRMOperador';
import { ContatoCRMOperadorGridDesktopComponent } from '../GridsDesktop/ContatoCRMOperador';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterContatoCRMOperador } from '../../Filters/ContatoCRMOperador';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ContatoCRMOperadorWindow from './ContatoCRMOperadorWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useContatoCRMOperadorList } from '../../Hooks/hookContatoCRMOperador';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ContatoCRMOperadorGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const contatocrmoperadorService = useMemo(() => {
    return new ContatoCRMOperadorService(
    new ContatoCRMOperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: contatocrmoperador, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useContatoCRMOperadorList(contatocrmoperadorService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedContatoCRMOperador, setSelectedContatoCRMOperador] = useState<IContatoCRMOperador>(ContatoCRMOperadorEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterContatoCRMOperador | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterContatoCRMOperador | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterContatoCRMOperador);
};
// Handlers para o grid
const handleRowClick = (contatocrmoperador: IContatoCRMOperador) => {
  setSelectedContatoCRMOperador(contatocrmoperador);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedContatoCRMOperador(ContatoCRMOperadorEmpty());
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
  const contatocrmoperador = e.dataItem;
  setDeleteId(contatocrmoperador.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await contatocrmoperadorService.deleteContatoCRMOperador(deleteId);
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
    <ContatoCRMOperadorGridMobileComponent
    data={contatocrmoperador}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ContatoCRMOperadorGridDesktopComponent
    data={contatocrmoperador}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ContatoCRMOperadorWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedContatoCRMOperador={selectedContatoCRMOperador}
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
export default ContatoCRMOperadorGrid;