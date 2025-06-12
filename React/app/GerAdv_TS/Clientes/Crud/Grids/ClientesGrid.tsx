//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ClientesEmpty } from '../../../Models/Clientes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IClientes } from '../../Interfaces/interface.Clientes';
import { ClientesService } from '../../Services/Clientes.service';
import { ClientesApi } from '../../Apis/ApiClientes';
import { ClientesGridMobileComponent } from '../GridsMobile/Clientes';
import { ClientesGridDesktopComponent } from '../GridsDesktop/Clientes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterClientes } from '../../Filters/Clientes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ClientesWindow from './ClientesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useClientesList } from '../../Hooks/hookClientes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ClientesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const clientesService = useMemo(() => {
    return new ClientesService(
    new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: clientes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useClientesList(clientesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedClientes, setSelectedClientes] = useState<IClientes>(ClientesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterClientes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterClientes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterClientes);
};
// Handlers para o grid
const handleRowClick = (clientes: IClientes) => {
  setSelectedClientes(clientes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedClientes(ClientesEmpty());
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
  const clientes = e.dataItem;
  setDeleteId(clientes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await clientesService.deleteClientes(deleteId);
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
    <ClientesGridMobileComponent
    data={clientes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ClientesGridDesktopComponent
    data={clientes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ClientesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedClientes={selectedClientes}
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
export default ClientesGrid;