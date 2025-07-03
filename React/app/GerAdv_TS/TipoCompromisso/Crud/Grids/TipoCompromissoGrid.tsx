//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoCompromissoEmpty } from '../../../Models/TipoCompromisso';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoCompromisso } from '../../Interfaces/interface.TipoCompromisso';
import { TipoCompromissoService } from '../../Services/TipoCompromisso.service';
import { TipoCompromissoApi } from '../../Apis/ApiTipoCompromisso';
import { TipoCompromissoGridMobileComponent } from '../GridsMobile/TipoCompromisso';
import { TipoCompromissoGridDesktopComponent } from '../GridsDesktop/TipoCompromisso';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoCompromisso } from '../../Filters/TipoCompromisso';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoCompromissoWindow from './TipoCompromissoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoCompromissoList } from '../../Hooks/hookTipoCompromisso';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoCompromissoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipocompromissoService = useMemo(() => {
    return new TipoCompromissoService(
    new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipocompromisso, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoCompromissoList(tipocompromissoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoCompromisso, setSelectedTipoCompromisso] = useState<ITipoCompromisso>(TipoCompromissoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoCompromisso | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoCompromisso | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoCompromisso);
};
// Handlers para o grid
const handleRowClick = (tipocompromisso: ITipoCompromisso) => {
  setSelectedTipoCompromisso(tipocompromisso);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoCompromisso(TipoCompromissoEmpty());
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
  const tipocompromisso = e.dataItem;
  setDeleteId(tipocompromisso.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipocompromissoService.deleteTipoCompromisso(deleteId);
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
    <TipoCompromissoGridMobileComponent
    data={tipocompromisso}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoCompromissoGridDesktopComponent
    data={tipocompromisso}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoCompromissoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoCompromisso={selectedTipoCompromisso}
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
export default TipoCompromissoGrid;