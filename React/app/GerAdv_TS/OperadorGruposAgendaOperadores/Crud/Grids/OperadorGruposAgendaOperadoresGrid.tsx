//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadorGruposAgendaOperadoresEmpty } from '../../../Models/OperadorGruposAgendaOperadores';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperadorGruposAgendaOperadores } from '../../Interfaces/interface.OperadorGruposAgendaOperadores';
import { OperadorGruposAgendaOperadoresService } from '../../Services/OperadorGruposAgendaOperadores.service';
import { OperadorGruposAgendaOperadoresApi } from '../../Apis/ApiOperadorGruposAgendaOperadores';
import { OperadorGruposAgendaOperadoresGridMobileComponent } from '../GridsMobile/OperadorGruposAgendaOperadores';
import { OperadorGruposAgendaOperadoresGridDesktopComponent } from '../GridsDesktop/OperadorGruposAgendaOperadores';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperadorGruposAgendaOperadores } from '../../Filters/OperadorGruposAgendaOperadores';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadorGruposAgendaOperadoresWindow from './OperadorGruposAgendaOperadoresWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadorGruposAgendaOperadoresList } from '../../Hooks/hookOperadorGruposAgendaOperadores';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadorGruposAgendaOperadoresGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadorgruposagendaoperadoresService = useMemo(() => {
    return new OperadorGruposAgendaOperadoresService(
    new OperadorGruposAgendaOperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operadorgruposagendaoperadores, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadorGruposAgendaOperadoresList(operadorgruposagendaoperadoresService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperadorGruposAgendaOperadores, setSelectedOperadorGruposAgendaOperadores] = useState<IOperadorGruposAgendaOperadores>(OperadorGruposAgendaOperadoresEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperadorGruposAgendaOperadores | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperadorGruposAgendaOperadores | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperadorGruposAgendaOperadores);
};
// Handlers para o grid
const handleRowClick = (operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores) => {
  setSelectedOperadorGruposAgendaOperadores(operadorgruposagendaoperadores);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperadorGruposAgendaOperadores(OperadorGruposAgendaOperadoresEmpty());
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
  const operadorgruposagendaoperadores = e.dataItem;
  setDeleteId(operadorgruposagendaoperadores.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadorgruposagendaoperadoresService.deleteOperadorGruposAgendaOperadores(deleteId);
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
    <OperadorGruposAgendaOperadoresGridMobileComponent
    data={operadorgruposagendaoperadores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadorGruposAgendaOperadoresGridDesktopComponent
    data={operadorgruposagendaoperadores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadorGruposAgendaOperadoresWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperadorGruposAgendaOperadores={selectedOperadorGruposAgendaOperadores}
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
export default OperadorGruposAgendaOperadoresGrid;