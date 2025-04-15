//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AndCompEmpty } from "../../../Models/AndComp";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AndCompInc from "../Inc/AndComp";
import { IAndComp } from "../../Interfaces/interface.AndComp";
import { AndCompService } from "../../Services/AndComp.service";
import { AndCompApi } from "../../Apis/ApiAndComp";
import { AndCompGridMobileComponent } from "../GridsMobile/AndComp";
import { AndCompGridDesktopComponent } from "../GridsDesktop/AndComp";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAndComp } from "../../Filters/AndComp";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AndCompWindow from "./AndCompWindow";

const AndCompGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [andcomp, setAndComp] = useState<IAndComp[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAndComp, setSelectedAndComp] = useState<IAndComp>(AndCompEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AndCompApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAndComp | undefined | null>(null);

    const andcompService = useMemo(() => {
      return new AndCompService(
          new AndCompApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAndComp = async (filtro?: FilterAndComp | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await andcompService.getAll(filtro ?? {} as FilterAndComp);
        setAndComp(data);
      }
      else {
        const data = await andcompService.getAll(filtro ?? {} as FilterAndComp);
        setAndComp(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAndComp(currFilter);
    }, [showInc]);
  
    const handleRowClick = (andcomp: IAndComp) => {
      if (isMobile) {
        router.push(`/pages/andcomp/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${andcomp.id}`);
      } else {
        setSelectedAndComp(andcomp);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/andcomp/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAndComp(AndCompEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAndComp(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const andcomp = e.dataItem;		
        setDeleteId(andcomp.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAndComp(currFilter);
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
           <AndCompGridMobileComponent data={andcomp} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AndCompGridDesktopComponent data={andcomp} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AndCompWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAndComp={selectedAndComp}>       
        </AndCompWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AndCompGrid;