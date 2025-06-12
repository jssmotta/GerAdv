//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadorGrupoEmpty } from '../../../Models/OperadorGrupo';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperadorGrupo } from '../../Interfaces/interface.OperadorGrupo';
import { OperadorGrupoService } from '../../Services/OperadorGrupo.service';
import { OperadorGrupoApi } from '../../Apis/ApiOperadorGrupo';
import { OperadorGrupoGridMobileComponent } from '../GridsMobile/OperadorGrupo';
import { OperadorGrupoGridDesktopComponent } from '../GridsDesktop/OperadorGrupo';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperadorGrupo } from '../../Filters/OperadorGrupo';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadorGrupoWindow from './OperadorGrupoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadorGrupoList } from '../../Hooks/hookOperadorGrupo';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadorGrupoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadorgrupoService = useMemo(() => {
    return new OperadorGrupoService(
    new OperadorGrupoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operadorgrupo, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadorGrupoList(operadorgrupoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperadorGrupo, setSelectedOperadorGrupo] = useState<IOperadorGrupo>(OperadorGrupoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperadorGrupo | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperadorGrupo | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperadorGrupo);
};
// Handlers para o grid
const handleRowClick = (operadorgrupo: IOperadorGrupo) => {
  setSelectedOperadorGrupo(operadorgrupo);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperadorGrupo(OperadorGrupoEmpty());
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
  const operadorgrupo = e.dataItem;
  setDeleteId(operadorgrupo.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadorgrupoService.deleteOperadorGrupo(deleteId);
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
    <OperadorGrupoGridMobileComponent
    data={operadorgrupo}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadorGrupoGridDesktopComponent
    data={operadorgrupo}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadorGrupoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperadorGrupo={selectedOperadorGrupo}
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
export default OperadorGrupoGrid;