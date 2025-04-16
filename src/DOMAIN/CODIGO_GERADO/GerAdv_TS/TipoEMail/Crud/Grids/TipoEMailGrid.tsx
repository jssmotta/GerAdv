//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoEMailEmpty } from "../../../Models/TipoEMail";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TipoEMailInc from "../Inc/TipoEMail";
import { ITipoEMail } from "../../Interfaces/interface.TipoEMail";
import { TipoEMailService } from "../../Services/TipoEMail.service";
import { TipoEMailApi } from "../../Apis/ApiTipoEMail";
import { TipoEMailGridMobileComponent } from "../GridsMobile/TipoEMail";
import { TipoEMailGridDesktopComponent } from "../GridsDesktop/TipoEMail";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoEMail } from "../../Filters/TipoEMail";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TipoEMailWindow from "./TipoEMailWindow";

const TipoEMailGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipoemail, setTipoEMail] = useState<ITipoEMail[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoEMail, setSelectedTipoEMail] = useState<ITipoEMail>(TipoEMailEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoEMail | undefined | null>(null);

    const tipoemailService = useMemo(() => {
      return new TipoEMailService(
          new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoEMail = async (filtro?: FilterTipoEMail | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipoemailService.getList(filtro ?? {} as FilterTipoEMail);
        setTipoEMail(data);
      }
      else {
        const data = await tipoemailService.getAll(filtro ?? {} as FilterTipoEMail);
        setTipoEMail(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoEMail(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipoemail: ITipoEMail) => {
      if (isMobile) {
        router.push(`/pages/tipoemail/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipoemail.id}`);
      } else {
        setSelectedTipoEMail(tipoemail);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipoemail/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoEMail(TipoEMailEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoEMail(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipoemail = e.dataItem;		
        setDeleteId(tipoemail.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoEMail(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <TipoEMailGridMobileComponent data={tipoemail} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TipoEMailGridDesktopComponent data={tipoemail} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TipoEMailWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoEMail={selectedTipoEMail}>       
        </TipoEMailWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoEMailGrid;