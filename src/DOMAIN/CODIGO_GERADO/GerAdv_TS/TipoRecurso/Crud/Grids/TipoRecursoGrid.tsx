//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoRecursoEmpty } from '../../../Models/TipoRecurso';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoRecurso } from '../../Interfaces/interface.TipoRecurso';
import { TipoRecursoService } from '../../Services/TipoRecurso.service';
import { TipoRecursoApi } from '../../Apis/ApiTipoRecurso';
import { TipoRecursoGridMobileComponent } from '../GridsMobile/TipoRecurso';
import { TipoRecursoGridDesktopComponent } from '../GridsDesktop/TipoRecurso';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoRecurso } from '../../Filters/TipoRecurso';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoRecursoWindow from './TipoRecursoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoRecursoList } from '../../Hooks/hookTipoRecurso';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoRecursoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tiporecursoService = useMemo(() => {
    return new TipoRecursoService(
    new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tiporecurso, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoRecursoList(tiporecursoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoRecurso, setSelectedTipoRecurso] = useState<ITipoRecurso>(TipoRecursoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoRecurso | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoRecurso | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoRecurso);
};
// Handlers para o grid
const handleRowClick = (tiporecurso: ITipoRecurso) => {
  setSelectedTipoRecurso(tiporecurso);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoRecurso(TipoRecursoEmpty());
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
  const tiporecurso = e.dataItem;
  setDeleteId(tiporecurso.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tiporecursoService.deleteTipoRecurso(deleteId);
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
    <TipoRecursoGridMobileComponent
    data={tiporecurso}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoRecursoGridDesktopComponent
    data={tiporecurso}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoRecursoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoRecurso={selectedTipoRecurso}
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
export default TipoRecursoGrid;