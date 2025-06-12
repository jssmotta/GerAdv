//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PreClientesEmpty } from '../../../Models/PreClientes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPreClientes } from '../../Interfaces/interface.PreClientes';
import { PreClientesService } from '../../Services/PreClientes.service';
import { PreClientesApi } from '../../Apis/ApiPreClientes';
import { PreClientesGridMobileComponent } from '../GridsMobile/PreClientes';
import { PreClientesGridDesktopComponent } from '../GridsDesktop/PreClientes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPreClientes } from '../../Filters/PreClientes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PreClientesWindow from './PreClientesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePreClientesList } from '../../Hooks/hookPreClientes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PreClientesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const preclientesService = useMemo(() => {
    return new PreClientesService(
    new PreClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: preclientes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePreClientesList(preclientesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPreClientes, setSelectedPreClientes] = useState<IPreClientes>(PreClientesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPreClientes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPreClientes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPreClientes);
};
// Handlers para o grid
const handleRowClick = (preclientes: IPreClientes) => {
  setSelectedPreClientes(preclientes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPreClientes(PreClientesEmpty());
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
  const preclientes = e.dataItem;
  setDeleteId(preclientes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await preclientesService.deletePreClientes(deleteId);
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
    <PreClientesGridMobileComponent
    data={preclientes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PreClientesGridDesktopComponent
    data={preclientes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PreClientesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPreClientes={selectedPreClientes}
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
export default PreClientesGrid;