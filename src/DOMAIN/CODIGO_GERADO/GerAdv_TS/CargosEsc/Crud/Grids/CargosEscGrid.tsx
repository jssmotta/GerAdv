//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { CargosEscEmpty } from "../../../Models/CargosEsc";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import CargosEscInc from "../Inc/CargosEsc";
import { ICargosEsc } from "../../Interfaces/interface.CargosEsc";
import { CargosEscService } from "../../Services/CargosEsc.service";
import { CargosEscApi } from "../../Apis/ApiCargosEsc";
import { CargosEscGridMobileComponent } from "../GridsMobile/CargosEsc";
import { CargosEscGridDesktopComponent } from "../GridsDesktop/CargosEsc";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterCargosEsc } from "../../Filters/CargosEsc";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import CargosEscWindow from "./CargosEscWindow";

const CargosEscGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [cargosesc, setCargosEsc] = useState<ICargosEsc[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedCargosEsc, setSelectedCargosEsc] = useState<ICargosEsc>(CargosEscEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new CargosEscApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterCargosEsc | undefined | null>(null);

    const cargosescService = useMemo(() => {
      return new CargosEscService(
          new CargosEscApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchCargosEsc = async (filtro?: FilterCargosEsc | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await cargosescService.getList(filtro ?? {} as FilterCargosEsc);
        setCargosEsc(data);
      }
      else {
        const data = await cargosescService.getAll(filtro ?? {} as FilterCargosEsc);
        setCargosEsc(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchCargosEsc(currFilter);
    }, [showInc]);
  
    const handleRowClick = (cargosesc: ICargosEsc) => {
      if (isMobile) {
        router.push(`/pages/cargosesc/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${cargosesc.id}`);
      } else {
        setSelectedCargosEsc(cargosesc);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/cargosesc/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedCargosEsc(CargosEscEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchCargosEsc(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const cargosesc = e.dataItem;		
        setDeleteId(cargosesc.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchCargosEsc(currFilter);
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
           <CargosEscGridMobileComponent data={cargosesc} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <CargosEscGridDesktopComponent data={cargosesc} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <CargosEscWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedCargosEsc={selectedCargosEsc}>       
        </CargosEscWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default CargosEscGrid;