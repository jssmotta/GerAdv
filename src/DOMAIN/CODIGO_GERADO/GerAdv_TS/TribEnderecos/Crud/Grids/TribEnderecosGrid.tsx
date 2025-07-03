//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TribEnderecosEmpty } from '../../../Models/TribEnderecos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITribEnderecos } from '../../Interfaces/interface.TribEnderecos';
import { TribEnderecosService } from '../../Services/TribEnderecos.service';
import { TribEnderecosApi } from '../../Apis/ApiTribEnderecos';
import { TribEnderecosGridMobileComponent } from '../GridsMobile/TribEnderecos';
import { TribEnderecosGridDesktopComponent } from '../GridsDesktop/TribEnderecos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTribEnderecos } from '../../Filters/TribEnderecos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TribEnderecosWindow from './TribEnderecosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTribEnderecosList } from '../../Hooks/hookTribEnderecos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TribEnderecosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tribenderecosService = useMemo(() => {
    return new TribEnderecosService(
    new TribEnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tribenderecos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTribEnderecosList(tribenderecosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTribEnderecos, setSelectedTribEnderecos] = useState<ITribEnderecos>(TribEnderecosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTribEnderecos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTribEnderecos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTribEnderecos);
};
// Handlers para o grid
const handleRowClick = (tribenderecos: ITribEnderecos) => {
  setSelectedTribEnderecos(tribenderecos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTribEnderecos(TribEnderecosEmpty());
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
  const tribenderecos = e.dataItem;
  setDeleteId(tribenderecos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tribenderecosService.deleteTribEnderecos(deleteId);
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
    <TribEnderecosGridMobileComponent
    data={tribenderecos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TribEnderecosGridDesktopComponent
    data={tribenderecos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TribEnderecosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTribEnderecos={selectedTribEnderecos}
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
export default TribEnderecosGrid;