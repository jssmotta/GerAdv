//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OutrasPartesClienteEmpty } from '../../../Models/OutrasPartesCliente';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOutrasPartesCliente } from '../../Interfaces/interface.OutrasPartesCliente';
import { OutrasPartesClienteService } from '../../Services/OutrasPartesCliente.service';
import { OutrasPartesClienteApi } from '../../Apis/ApiOutrasPartesCliente';
import { OutrasPartesClienteGridMobileComponent } from '../GridsMobile/OutrasPartesCliente';
import { OutrasPartesClienteGridDesktopComponent } from '../GridsDesktop/OutrasPartesCliente';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOutrasPartesCliente } from '../../Filters/OutrasPartesCliente';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OutrasPartesClienteWindow from './OutrasPartesClienteWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOutrasPartesClienteList } from '../../Hooks/hookOutrasPartesCliente';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const OutrasPartesClienteGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const outraspartesclienteService = useMemo(() => {
    return new OutrasPartesClienteService(
    new OutrasPartesClienteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: outraspartescliente, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOutrasPartesClienteList(outraspartesclienteService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOutrasPartesCliente, setSelectedOutrasPartesCliente] = useState<IOutrasPartesCliente>(OutrasPartesClienteEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOutrasPartesCliente | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOutrasPartesCliente | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOutrasPartesCliente);
};
// Handlers para o grid
const handleRowClick = (outraspartescliente: IOutrasPartesCliente) => {
  setSelectedOutrasPartesCliente(outraspartescliente);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOutrasPartesCliente(OutrasPartesClienteEmpty());
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
  const outraspartescliente = e.dataItem;
  setDeleteId(outraspartescliente.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await outraspartesclienteService.deleteOutrasPartesCliente(deleteId);
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
    <OutrasPartesClienteGridMobileComponent
    data={outraspartescliente}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OutrasPartesClienteGridDesktopComponent
    data={outraspartescliente}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OutrasPartesClienteWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOutrasPartesCliente={selectedOutrasPartesCliente}
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
export default OutrasPartesClienteGrid;