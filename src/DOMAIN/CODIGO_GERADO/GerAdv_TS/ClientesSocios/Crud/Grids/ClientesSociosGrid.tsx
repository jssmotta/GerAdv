//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ClientesSociosEmpty } from '../../../Models/ClientesSocios';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IClientesSocios } from '../../Interfaces/interface.ClientesSocios';
import { ClientesSociosService } from '../../Services/ClientesSocios.service';
import { ClientesSociosApi } from '../../Apis/ApiClientesSocios';
import { ClientesSociosGridMobileComponent } from '../GridsMobile/ClientesSocios';
import { ClientesSociosGridDesktopComponent } from '../GridsDesktop/ClientesSocios';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterClientesSocios } from '../../Filters/ClientesSocios';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ClientesSociosWindow from './ClientesSociosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useClientesSociosList } from '../../Hooks/hookClientesSocios';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ClientesSociosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const clientessociosService = useMemo(() => {
    return new ClientesSociosService(
    new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: clientessocios, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useClientesSociosList(clientessociosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedClientesSocios, setSelectedClientesSocios] = useState<IClientesSocios>(ClientesSociosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterClientesSocios | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterClientesSocios | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterClientesSocios);
};
// Handlers para o grid
const handleRowClick = (clientessocios: IClientesSocios) => {
  setSelectedClientesSocios(clientessocios);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedClientesSocios(ClientesSociosEmpty());
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
  const clientessocios = e.dataItem;
  setDeleteId(clientessocios.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await clientessociosService.deleteClientesSocios(deleteId);
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
    <ClientesSociosGridMobileComponent
    data={clientessocios}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ClientesSociosGridDesktopComponent
    data={clientessocios}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ClientesSociosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedClientesSocios={selectedClientesSocios}
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
export default ClientesSociosGrid;