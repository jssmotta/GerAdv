//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ApensoEmpty } from '../../../Models/Apenso';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IApenso } from '../../Interfaces/interface.Apenso';
import { ApensoService } from '../../Services/Apenso.service';
import { ApensoApi } from '../../Apis/ApiApenso';
import { ApensoGridMobileComponent } from '../GridsMobile/Apenso';
import { ApensoGridDesktopComponent } from '../GridsDesktop/Apenso';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterApenso } from '../../Filters/Apenso';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ApensoWindow from './ApensoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useApensoList } from '../../Hooks/hookApenso';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ApensoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const apensoService = useMemo(() => {
    return new ApensoService(
    new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: apenso, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useApensoList(apensoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedApenso, setSelectedApenso] = useState<IApenso>(ApensoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterApenso | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterApenso | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterApenso);
};
// Handlers para o grid
const handleRowClick = (apenso: IApenso) => {
  setSelectedApenso(apenso);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedApenso(ApensoEmpty());
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
  const apenso = e.dataItem;
  setDeleteId(apenso.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await apensoService.deleteApenso(deleteId);
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
    <ApensoGridMobileComponent
    data={apenso}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ApensoGridDesktopComponent
    data={apenso}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ApensoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedApenso={selectedApenso}
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
export default ApensoGrid;