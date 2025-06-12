//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ColaboradoresEmpty } from '../../../Models/Colaboradores';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IColaboradores } from '../../Interfaces/interface.Colaboradores';
import { ColaboradoresService } from '../../Services/Colaboradores.service';
import { ColaboradoresApi } from '../../Apis/ApiColaboradores';
import { ColaboradoresGridMobileComponent } from '../GridsMobile/Colaboradores';
import { ColaboradoresGridDesktopComponent } from '../GridsDesktop/Colaboradores';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterColaboradores } from '../../Filters/Colaboradores';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ColaboradoresWindow from './ColaboradoresWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useColaboradoresList } from '../../Hooks/hookColaboradores';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ColaboradoresGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const colaboradoresService = useMemo(() => {
    return new ColaboradoresService(
    new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: colaboradores, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useColaboradoresList(colaboradoresService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedColaboradores, setSelectedColaboradores] = useState<IColaboradores>(ColaboradoresEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterColaboradores | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterColaboradores | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterColaboradores);
};
// Handlers para o grid
const handleRowClick = (colaboradores: IColaboradores) => {
  setSelectedColaboradores(colaboradores);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedColaboradores(ColaboradoresEmpty());
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
  const colaboradores = e.dataItem;
  setDeleteId(colaboradores.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await colaboradoresService.deleteColaboradores(deleteId);
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
    <ColaboradoresGridMobileComponent
    data={colaboradores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ColaboradoresGridDesktopComponent
    data={colaboradores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ColaboradoresWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedColaboradores={selectedColaboradores}
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
export default ColaboradoresGrid;