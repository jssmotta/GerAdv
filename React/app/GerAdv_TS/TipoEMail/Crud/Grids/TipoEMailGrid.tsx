//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoEMailEmpty } from '../../../Models/TipoEMail';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoEMail } from '../../Interfaces/interface.TipoEMail';
import { TipoEMailService } from '../../Services/TipoEMail.service';
import { TipoEMailApi } from '../../Apis/ApiTipoEMail';
import { TipoEMailGridMobileComponent } from '../GridsMobile/TipoEMail';
import { TipoEMailGridDesktopComponent } from '../GridsDesktop/TipoEMail';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoEMail } from '../../Filters/TipoEMail';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoEMailWindow from './TipoEMailWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoEMailList } from '../../Hooks/hookTipoEMail';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoEMailGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipoemailService = useMemo(() => {
    return new TipoEMailService(
    new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipoemail, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoEMailList(tipoemailService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoEMail, setSelectedTipoEMail] = useState<ITipoEMail>(TipoEMailEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoEMail | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoEMail | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoEMail);
};
// Handlers para o grid
const handleRowClick = (tipoemail: ITipoEMail) => {
  setSelectedTipoEMail(tipoemail);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoEMail(TipoEMailEmpty());
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
  const tipoemail = e.dataItem;
  setDeleteId(tipoemail.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipoemailService.deleteTipoEMail(deleteId);
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
    <TipoEMailGridMobileComponent
    data={tipoemail}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoEMailGridDesktopComponent
    data={tipoemail}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoEMailWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoEMail={selectedTipoEMail}
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
export default TipoEMailGrid;