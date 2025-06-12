//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { Apenso2Empty } from '../../../Models/Apenso2';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IApenso2 } from '../../Interfaces/interface.Apenso2';
import { Apenso2Service } from '../../Services/Apenso2.service';
import { Apenso2Api } from '../../Apis/ApiApenso2';
import { Apenso2GridMobileComponent } from '../GridsMobile/Apenso2';
import { Apenso2GridDesktopComponent } from '../GridsDesktop/Apenso2';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterApenso2 } from '../../Filters/Apenso2';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import Apenso2Window from './Apenso2Window';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useApenso2List } from '../../Hooks/hookApenso2';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const Apenso2Grid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const apenso2Service = useMemo(() => {
    return new Apenso2Service(
    new Apenso2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: apenso2, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useApenso2List(apenso2Service);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedApenso2, setSelectedApenso2] = useState<IApenso2>(Apenso2Empty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterApenso2 | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterApenso2 | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterApenso2);
};
// Handlers para o grid
const handleRowClick = (apenso2: IApenso2) => {
  setSelectedApenso2(apenso2);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedApenso2(Apenso2Empty());
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
  const apenso2 = e.dataItem;
  setDeleteId(apenso2.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await apenso2Service.deleteApenso2(deleteId);
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
    <Apenso2GridMobileComponent
    data={apenso2}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <Apenso2GridDesktopComponent
    data={apenso2}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <Apenso2Window
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedApenso2={selectedApenso2}
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
export default Apenso2Grid;