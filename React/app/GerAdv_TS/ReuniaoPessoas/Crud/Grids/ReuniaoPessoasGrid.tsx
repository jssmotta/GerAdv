//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ReuniaoPessoasEmpty } from '../../../Models/ReuniaoPessoas';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IReuniaoPessoas } from '../../Interfaces/interface.ReuniaoPessoas';
import { ReuniaoPessoasService } from '../../Services/ReuniaoPessoas.service';
import { ReuniaoPessoasApi } from '../../Apis/ApiReuniaoPessoas';
import { ReuniaoPessoasGridMobileComponent } from '../GridsMobile/ReuniaoPessoas';
import { ReuniaoPessoasGridDesktopComponent } from '../GridsDesktop/ReuniaoPessoas';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterReuniaoPessoas } from '../../Filters/ReuniaoPessoas';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ReuniaoPessoasWindow from './ReuniaoPessoasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useReuniaoPessoasList } from '../../Hooks/hookReuniaoPessoas';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ReuniaoPessoasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const reuniaopessoasService = useMemo(() => {
    return new ReuniaoPessoasService(
    new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: reuniaopessoas, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useReuniaoPessoasList(reuniaopessoasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedReuniaoPessoas, setSelectedReuniaoPessoas] = useState<IReuniaoPessoas>(ReuniaoPessoasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterReuniaoPessoas | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterReuniaoPessoas | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterReuniaoPessoas);
};
// Handlers para o grid
const handleRowClick = (reuniaopessoas: IReuniaoPessoas) => {
  setSelectedReuniaoPessoas(reuniaopessoas);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedReuniaoPessoas(ReuniaoPessoasEmpty());
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
  const reuniaopessoas = e.dataItem;
  setDeleteId(reuniaopessoas.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await reuniaopessoasService.deleteReuniaoPessoas(deleteId);
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
    <ReuniaoPessoasGridMobileComponent
    data={reuniaopessoas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ReuniaoPessoasGridDesktopComponent
    data={reuniaopessoas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ReuniaoPessoasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedReuniaoPessoas={selectedReuniaoPessoas}
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
export default ReuniaoPessoasGrid;