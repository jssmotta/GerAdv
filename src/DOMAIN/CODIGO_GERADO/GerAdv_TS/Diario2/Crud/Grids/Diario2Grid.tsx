//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { Diario2Empty } from "../../../Models/Diario2";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import Diario2Inc from "../Inc/Diario2";
import { IDiario2 } from "../../Interfaces/interface.Diario2";
import { Diario2Service } from "../../Services/Diario2.service";
import { Diario2Api } from "../../Apis/ApiDiario2";
import { Diario2GridMobileComponent } from "../GridsMobile/Diario2";
import { Diario2GridDesktopComponent } from "../GridsDesktop/Diario2";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterDiario2 } from "../../Filters/Diario2";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import Diario2Window from "./Diario2Window";

const Diario2Grid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [diario2, setDiario2] = useState<IDiario2[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedDiario2, setSelectedDiario2] = useState<IDiario2>(Diario2Empty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new Diario2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterDiario2 | undefined | null>(null);

    const diario2Service = useMemo(() => {
      return new Diario2Service(
          new Diario2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchDiario2 = async (filtro?: FilterDiario2 | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await diario2Service.getList(filtro ?? {} as FilterDiario2);
        setDiario2(data);
      }
      else {
        const data = await diario2Service.getAll(filtro ?? {} as FilterDiario2);
        setDiario2(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchDiario2(currFilter);
    }, [showInc]);
  
    const handleRowClick = (diario2: IDiario2) => {
      if (isMobile) {
        router.push(`/pages/diario2/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${diario2.id}`);
      } else {
        setSelectedDiario2(diario2);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/diario2/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedDiario2(Diario2Empty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchDiario2(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const diario2 = e.dataItem;		
        setDeleteId(diario2.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchDiario2(currFilter);
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
           <Diario2GridMobileComponent data={diario2} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <Diario2GridDesktopComponent data={diario2} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <Diario2Window
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedDiario2={selectedDiario2}>       
        </Diario2Window>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default Diario2Grid;