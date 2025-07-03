//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadorGruposEmpty } from '../../../Models/OperadorGrupos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperadorGrupos } from '../../Interfaces/interface.OperadorGrupos';
import { OperadorGruposService } from '../../Services/OperadorGrupos.service';
import { OperadorGruposApi } from '../../Apis/ApiOperadorGrupos';
import { OperadorGruposGridMobileComponent } from '../GridsMobile/OperadorGrupos';
import { OperadorGruposGridDesktopComponent } from '../GridsDesktop/OperadorGrupos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperadorGrupos } from '../../Filters/OperadorGrupos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadorGruposWindow from './OperadorGruposWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadorGruposList } from '../../Hooks/hookOperadorGrupos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadorGruposGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadorgruposService = useMemo(() => {
    return new OperadorGruposService(
    new OperadorGruposApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operadorgrupos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadorGruposList(operadorgruposService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperadorGrupos, setSelectedOperadorGrupos] = useState<IOperadorGrupos>(OperadorGruposEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperadorGrupos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperadorGrupos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperadorGrupos);
};
// Handlers para o grid
const handleRowClick = (operadorgrupos: IOperadorGrupos) => {
  setSelectedOperadorGrupos(operadorgrupos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperadorGrupos(OperadorGruposEmpty());
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
  const operadorgrupos = e.dataItem;
  setDeleteId(operadorgrupos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadorgruposService.deleteOperadorGrupos(deleteId);
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
    <OperadorGruposGridMobileComponent
    data={operadorgrupos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadorGruposGridDesktopComponent
    data={operadorgrupos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadorGruposWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperadorGrupos={selectedOperadorGrupos}
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
export default OperadorGruposGrid;