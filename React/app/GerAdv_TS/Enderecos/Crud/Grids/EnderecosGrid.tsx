//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EnderecosEmpty } from '../../../Models/Enderecos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEnderecos } from '../../Interfaces/interface.Enderecos';
import { EnderecosService } from '../../Services/Enderecos.service';
import { EnderecosApi } from '../../Apis/ApiEnderecos';
import { EnderecosGridMobileComponent } from '../GridsMobile/Enderecos';
import { EnderecosGridDesktopComponent } from '../GridsDesktop/Enderecos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEnderecos } from '../../Filters/Enderecos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EnderecosWindow from './EnderecosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEnderecosList } from '../../Hooks/hookEnderecos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const EnderecosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const enderecosService = useMemo(() => {
    return new EnderecosService(
    new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: enderecos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEnderecosList(enderecosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEnderecos, setSelectedEnderecos] = useState<IEnderecos>(EnderecosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEnderecos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEnderecos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEnderecos);
};
// Handlers para o grid
const handleRowClick = (enderecos: IEnderecos) => {
  setSelectedEnderecos(enderecos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEnderecos(EnderecosEmpty());
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
  const enderecos = e.dataItem;
  setDeleteId(enderecos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await enderecosService.deleteEnderecos(deleteId);
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
    <EnderecosGridMobileComponent
    data={enderecos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EnderecosGridDesktopComponent
    data={enderecos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EnderecosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEnderecos={selectedEnderecos}
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
export default EnderecosGrid;