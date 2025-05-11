//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { Apenso2Empty } from "../../../Models/Apenso2";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IApenso2 } from "../../Interfaces/interface.Apenso2";
import { Apenso2Service } from "../../Services/Apenso2.service";
import { Apenso2Api } from "../../Apis/ApiApenso2";
import { Apenso2GridMobileComponent } from "../GridsMobile/Apenso2";
import { Apenso2GridDesktopComponent } from "../GridsDesktop/Apenso2";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterApenso2 } from "../../Filters/Apenso2";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import Apenso2Window from "./Apenso2Window";

const Apenso2Grid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [apenso2, setApenso2] = useState<IApenso2[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedApenso2, setSelectedApenso2] = useState<IApenso2>(Apenso2Empty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new Apenso2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterApenso2 | undefined | null>(null);

    const apenso2Service = useMemo(() => {
      return new Apenso2Service(
          new Apenso2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchApenso2 = async (filtro?: FilterApenso2 | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await apenso2Service.getAll(filtro ?? {} as FilterApenso2);
        setApenso2(data);
      }
      else {
        const data = await apenso2Service.getAll(filtro ?? {} as FilterApenso2);
        setApenso2(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchApenso2(currFilter);
    }, [showInc]);
  
    const handleRowClick = (apenso2: IApenso2) => {
      if (isMobile) {
        router.push(`/pages/apenso2/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${apenso2.id}`);
      } else {
        setSelectedApenso2(apenso2);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/apenso2/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedApenso2(Apenso2Empty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchApenso2(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const apenso2 = e.dataItem;		
        setDeleteId(apenso2.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchApenso2(currFilter);
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
           <Apenso2GridMobileComponent data={apenso2} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <Apenso2GridDesktopComponent data={apenso2} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <Apenso2Window
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedApenso2={selectedApenso2}>       
        </Apenso2Window>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default Apenso2Grid;