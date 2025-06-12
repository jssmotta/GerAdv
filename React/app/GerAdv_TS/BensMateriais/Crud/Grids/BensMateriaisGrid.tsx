//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { BensMateriaisEmpty } from '../../../Models/BensMateriais';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IBensMateriais } from '../../Interfaces/interface.BensMateriais';
import { BensMateriaisService } from '../../Services/BensMateriais.service';
import { BensMateriaisApi } from '../../Apis/ApiBensMateriais';
import { BensMateriaisGridMobileComponent } from '../GridsMobile/BensMateriais';
import { BensMateriaisGridDesktopComponent } from '../GridsDesktop/BensMateriais';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterBensMateriais } from '../../Filters/BensMateriais';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import BensMateriaisWindow from './BensMateriaisWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useBensMateriaisList } from '../../Hooks/hookBensMateriais';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const BensMateriaisGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const bensmateriaisService = useMemo(() => {
    return new BensMateriaisService(
    new BensMateriaisApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: bensmateriais, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useBensMateriaisList(bensmateriaisService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedBensMateriais, setSelectedBensMateriais] = useState<IBensMateriais>(BensMateriaisEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterBensMateriais | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterBensMateriais | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterBensMateriais);
};
// Handlers para o grid
const handleRowClick = (bensmateriais: IBensMateriais) => {
  setSelectedBensMateriais(bensmateriais);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedBensMateriais(BensMateriaisEmpty());
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
  const bensmateriais = e.dataItem;
  setDeleteId(bensmateriais.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await bensmateriaisService.deleteBensMateriais(deleteId);
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
    <BensMateriaisGridMobileComponent
    data={bensmateriais}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <BensMateriaisGridDesktopComponent
    data={bensmateriais}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <BensMateriaisWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedBensMateriais={selectedBensMateriais}
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
export default BensMateriaisGrid;