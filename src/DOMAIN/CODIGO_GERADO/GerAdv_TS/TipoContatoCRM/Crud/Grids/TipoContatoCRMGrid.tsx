//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoContatoCRMEmpty } from "../../../Models/TipoContatoCRM";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TipoContatoCRMInc from "../Inc/TipoContatoCRM";
import { ITipoContatoCRM } from "../../Interfaces/interface.TipoContatoCRM";
import { TipoContatoCRMService } from "../../Services/TipoContatoCRM.service";
import { TipoContatoCRMApi } from "../../Apis/ApiTipoContatoCRM";
import { TipoContatoCRMGridMobileComponent } from "../GridsMobile/TipoContatoCRM";
import { TipoContatoCRMGridDesktopComponent } from "../GridsDesktop/TipoContatoCRM";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoContatoCRM } from "../../Filters/TipoContatoCRM";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TipoContatoCRMWindow from "./TipoContatoCRMWindow";

const TipoContatoCRMGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipocontatocrm, setTipoContatoCRM] = useState<ITipoContatoCRM[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoContatoCRM, setSelectedTipoContatoCRM] = useState<ITipoContatoCRM>(TipoContatoCRMEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoContatoCRM | undefined | null>(null);

    const tipocontatocrmService = useMemo(() => {
      return new TipoContatoCRMService(
          new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoContatoCRM = async (filtro?: FilterTipoContatoCRM | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipocontatocrmService.getList(filtro ?? {} as FilterTipoContatoCRM);
        setTipoContatoCRM(data);
      }
      else {
        const data = await tipocontatocrmService.getAll(filtro ?? {} as FilterTipoContatoCRM);
        setTipoContatoCRM(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoContatoCRM(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipocontatocrm: ITipoContatoCRM) => {
      if (isMobile) {
        router.push(`/pages/tipocontatocrm/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipocontatocrm.id}`);
      } else {
        setSelectedTipoContatoCRM(tipocontatocrm);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipocontatocrm/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoContatoCRM(TipoContatoCRMEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoContatoCRM(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipocontatocrm = e.dataItem;		
        setDeleteId(tipocontatocrm.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoContatoCRM(currFilter);
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
           <TipoContatoCRMGridMobileComponent data={tipocontatocrm} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TipoContatoCRMGridDesktopComponent data={tipocontatocrm} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TipoContatoCRMWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoContatoCRM={selectedTipoContatoCRM}>       
        </TipoContatoCRMWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoContatoCRMGrid;