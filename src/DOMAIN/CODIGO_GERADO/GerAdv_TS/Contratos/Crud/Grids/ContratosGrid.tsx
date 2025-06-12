//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ContratosEmpty } from '../../../Models/Contratos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IContratos } from '../../Interfaces/interface.Contratos';
import { ContratosService } from '../../Services/Contratos.service';
import { ContratosApi } from '../../Apis/ApiContratos';
import { ContratosGridMobileComponent } from '../GridsMobile/Contratos';
import { ContratosGridDesktopComponent } from '../GridsDesktop/Contratos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterContratos } from '../../Filters/Contratos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ContratosWindow from './ContratosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useContratosList } from '../../Hooks/hookContratos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ContratosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const contratosService = useMemo(() => {
    return new ContratosService(
    new ContratosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: contratos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useContratosList(contratosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedContratos, setSelectedContratos] = useState<IContratos>(ContratosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterContratos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterContratos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterContratos);
};
// Handlers para o grid
const handleRowClick = (contratos: IContratos) => {
  setSelectedContratos(contratos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedContratos(ContratosEmpty());
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
  const contratos = e.dataItem;
  setDeleteId(contratos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await contratosService.deleteContratos(deleteId);
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
    <ContratosGridMobileComponent
    data={contratos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ContratosGridDesktopComponent
    data={contratos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ContratosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedContratos={selectedContratos}
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
export default ContratosGrid;