//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadoresEmpty } from '../../../Models/Operadores';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperadores } from '../../Interfaces/interface.Operadores';
import { OperadoresService } from '../../Services/Operadores.service';
import { OperadoresApi } from '../../Apis/ApiOperadores';
import { OperadoresGridMobileComponent } from '../GridsMobile/Operadores';
import { OperadoresGridDesktopComponent } from '../GridsDesktop/Operadores';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperadores } from '../../Filters/Operadores';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadoresWindow from './OperadoresWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadoresList } from '../../Hooks/hookOperadores';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadoresGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadoresService = useMemo(() => {
    return new OperadoresService(
    new OperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operadores, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadoresList(operadoresService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperadores, setSelectedOperadores] = useState<IOperadores>(OperadoresEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperadores | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperadores | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperadores);
};
// Handlers para o grid
const handleRowClick = (operadores: IOperadores) => {
  setSelectedOperadores(operadores);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperadores(OperadoresEmpty());
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
  const operadores = e.dataItem;
  setDeleteId(operadores.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadoresService.deleteOperadores(deleteId);
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
    <OperadoresGridMobileComponent
    data={operadores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadoresGridDesktopComponent
    data={operadores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadoresWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperadores={selectedOperadores}
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
export default OperadoresGrid;