//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProProcuradoresEmpty } from '../../../Models/ProProcuradores';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProProcuradores } from '../../Interfaces/interface.ProProcuradores';
import { ProProcuradoresService } from '../../Services/ProProcuradores.service';
import { ProProcuradoresApi } from '../../Apis/ApiProProcuradores';
import { ProProcuradoresGridMobileComponent } from '../GridsMobile/ProProcuradores';
import { ProProcuradoresGridDesktopComponent } from '../GridsDesktop/ProProcuradores';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProProcuradores } from '../../Filters/ProProcuradores';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProProcuradoresWindow from './ProProcuradoresWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProProcuradoresList } from '../../Hooks/hookProProcuradores';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProProcuradoresGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const proprocuradoresService = useMemo(() => {
    return new ProProcuradoresService(
    new ProProcuradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: proprocuradores, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProProcuradoresList(proprocuradoresService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProProcuradores, setSelectedProProcuradores] = useState<IProProcuradores>(ProProcuradoresEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProProcuradores | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProProcuradores | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProProcuradores);
};
// Handlers para o grid
const handleRowClick = (proprocuradores: IProProcuradores) => {
  setSelectedProProcuradores(proprocuradores);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProProcuradores(ProProcuradoresEmpty());
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
  const proprocuradores = e.dataItem;
  setDeleteId(proprocuradores.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await proprocuradoresService.deleteProProcuradores(deleteId);
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
    <ProProcuradoresGridMobileComponent
    data={proprocuradores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProProcuradoresGridDesktopComponent
    data={proprocuradores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProProcuradoresWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProProcuradores={selectedProProcuradores}
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
export default ProProcuradoresGrid;