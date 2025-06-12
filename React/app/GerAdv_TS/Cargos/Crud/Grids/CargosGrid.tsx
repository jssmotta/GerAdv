//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { CargosEmpty } from '../../../Models/Cargos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ICargos } from '../../Interfaces/interface.Cargos';
import { CargosService } from '../../Services/Cargos.service';
import { CargosApi } from '../../Apis/ApiCargos';
import { CargosGridMobileComponent } from '../GridsMobile/Cargos';
import { CargosGridDesktopComponent } from '../GridsDesktop/Cargos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterCargos } from '../../Filters/Cargos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import CargosWindow from './CargosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useCargosList } from '../../Hooks/hookCargos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const CargosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const cargosService = useMemo(() => {
    return new CargosService(
    new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: cargos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useCargosList(cargosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedCargos, setSelectedCargos] = useState<ICargos>(CargosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterCargos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterCargos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterCargos);
};
// Handlers para o grid
const handleRowClick = (cargos: ICargos) => {
  setSelectedCargos(cargos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedCargos(CargosEmpty());
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
  const cargos = e.dataItem;
  setDeleteId(cargos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await cargosService.deleteCargos(deleteId);
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
    <CargosGridMobileComponent
    data={cargos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <CargosGridDesktopComponent
    data={cargos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <CargosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedCargos={selectedCargos}
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
export default CargosGrid;