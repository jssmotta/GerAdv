//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { LivroCaixaClientesEmpty } from '../../../Models/LivroCaixaClientes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ILivroCaixaClientes } from '../../Interfaces/interface.LivroCaixaClientes';
import { LivroCaixaClientesService } from '../../Services/LivroCaixaClientes.service';
import { LivroCaixaClientesApi } from '../../Apis/ApiLivroCaixaClientes';
import { LivroCaixaClientesGridMobileComponent } from '../GridsMobile/LivroCaixaClientes';
import { LivroCaixaClientesGridDesktopComponent } from '../GridsDesktop/LivroCaixaClientes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterLivroCaixaClientes } from '../../Filters/LivroCaixaClientes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import LivroCaixaClientesWindow from './LivroCaixaClientesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useLivroCaixaClientesList } from '../../Hooks/hookLivroCaixaClientes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const LivroCaixaClientesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const livrocaixaclientesService = useMemo(() => {
    return new LivroCaixaClientesService(
    new LivroCaixaClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: livrocaixaclientes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useLivroCaixaClientesList(livrocaixaclientesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedLivroCaixaClientes, setSelectedLivroCaixaClientes] = useState<ILivroCaixaClientes>(LivroCaixaClientesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterLivroCaixaClientes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterLivroCaixaClientes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterLivroCaixaClientes);
};
// Handlers para o grid
const handleRowClick = (livrocaixaclientes: ILivroCaixaClientes) => {
  setSelectedLivroCaixaClientes(livrocaixaclientes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedLivroCaixaClientes(LivroCaixaClientesEmpty());
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
  const livrocaixaclientes = e.dataItem;
  setDeleteId(livrocaixaclientes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await livrocaixaclientesService.deleteLivroCaixaClientes(deleteId);
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
    <LivroCaixaClientesGridMobileComponent
    data={livrocaixaclientes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <LivroCaixaClientesGridDesktopComponent
    data={livrocaixaclientes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <LivroCaixaClientesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedLivroCaixaClientes={selectedLivroCaixaClientes}
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
export default LivroCaixaClientesGrid;