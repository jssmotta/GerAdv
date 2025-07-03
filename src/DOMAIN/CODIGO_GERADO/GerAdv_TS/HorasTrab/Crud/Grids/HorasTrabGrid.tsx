//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { HorasTrabEmpty } from '../../../Models/HorasTrab';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IHorasTrab } from '../../Interfaces/interface.HorasTrab';
import { HorasTrabService } from '../../Services/HorasTrab.service';
import { HorasTrabApi } from '../../Apis/ApiHorasTrab';
import { HorasTrabGridMobileComponent } from '../GridsMobile/HorasTrab';
import { HorasTrabGridDesktopComponent } from '../GridsDesktop/HorasTrab';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterHorasTrab } from '../../Filters/HorasTrab';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import HorasTrabWindow from './HorasTrabWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useHorasTrabList } from '../../Hooks/hookHorasTrab';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const HorasTrabGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const horastrabService = useMemo(() => {
    return new HorasTrabService(
    new HorasTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: horastrab, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useHorasTrabList(horastrabService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedHorasTrab, setSelectedHorasTrab] = useState<IHorasTrab>(HorasTrabEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterHorasTrab | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterHorasTrab | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterHorasTrab);
};
// Handlers para o grid
const handleRowClick = (horastrab: IHorasTrab) => {
  setSelectedHorasTrab(horastrab);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedHorasTrab(HorasTrabEmpty());
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
  const horastrab = e.dataItem;
  setDeleteId(horastrab.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await horastrabService.deleteHorasTrab(deleteId);
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
    <HorasTrabGridMobileComponent
    data={horastrab}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <HorasTrabGridDesktopComponent
    data={horastrab}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <HorasTrabWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedHorasTrab={selectedHorasTrab}
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
export default HorasTrabGrid;