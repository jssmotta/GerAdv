//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadorEmpty } from '../../../Models/Operador';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperador } from '../../Interfaces/interface.Operador';
import { OperadorService } from '../../Services/Operador.service';
import { OperadorApi } from '../../Apis/ApiOperador';
import { OperadorGridMobileComponent } from '../GridsMobile/Operador';
import { OperadorGridDesktopComponent } from '../GridsDesktop/Operador';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperador } from '../../Filters/Operador';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadorWindow from './OperadorWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadorList } from '../../Hooks/hookOperador';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadorGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadorService = useMemo(() => {
    return new OperadorService(
    new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operador, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadorList(operadorService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperador, setSelectedOperador] = useState<IOperador>(OperadorEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperador | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperador | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperador);
};
// Handlers para o grid
const handleRowClick = (operador: IOperador) => {
  setSelectedOperador(operador);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperador(OperadorEmpty());
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
  const operador = e.dataItem;
  setDeleteId(operador.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadorService.deleteOperador(deleteId);
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
    <OperadorGridMobileComponent
    data={operador}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadorGridDesktopComponent
    data={operador}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadorWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperador={selectedOperador}
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
export default OperadorGrid;