//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ApensoEmpty } from "../../../Models/Apenso";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ApensoInc from "../Inc/Apenso";
import { IApenso } from "../../Interfaces/interface.Apenso";
import { ApensoService } from "../../Services/Apenso.service";
import { ApensoApi } from "../../Apis/ApiApenso";
import { ApensoGridMobileComponent } from "../GridsMobile/Apenso";
import { ApensoGridDesktopComponent } from "../GridsDesktop/Apenso";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterApenso } from "../../Filters/Apenso";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ApensoWindow from "./ApensoWindow";

const ApensoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [apenso, setApenso] = useState<IApenso[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedApenso, setSelectedApenso] = useState<IApenso>(ApensoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterApenso | undefined | null>(null);

    const apensoService = useMemo(() => {
      return new ApensoService(
          new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchApenso = async (filtro?: FilterApenso | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await apensoService.getAll(filtro ?? {} as FilterApenso);
        setApenso(data);
      }
      else {
        const data = await apensoService.getAll(filtro ?? {} as FilterApenso);
        setApenso(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchApenso(currFilter);
    }, [showInc]);
  
    const handleRowClick = (apenso: IApenso) => {
      if (isMobile) {
        router.push(`/pages/apenso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${apenso.id}`);
      } else {
        setSelectedApenso(apenso);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/apenso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedApenso(ApensoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchApenso(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const apenso = e.dataItem;		
        setDeleteId(apenso.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchApenso(currFilter);
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
            
        {isMobile ?
           <ApensoGridMobileComponent data={apenso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ApensoGridDesktopComponent data={apenso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ApensoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedApenso={selectedApenso}>       
        </ApensoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ApensoGrid;