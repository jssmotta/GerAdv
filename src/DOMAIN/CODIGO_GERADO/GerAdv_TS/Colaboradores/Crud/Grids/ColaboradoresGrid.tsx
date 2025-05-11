//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ColaboradoresEmpty } from "../../../Models/Colaboradores";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IColaboradores } from "../../Interfaces/interface.Colaboradores";
import { ColaboradoresService } from "../../Services/Colaboradores.service";
import { ColaboradoresApi } from "../../Apis/ApiColaboradores";
import { ColaboradoresGridMobileComponent } from "../GridsMobile/Colaboradores";
import { ColaboradoresGridDesktopComponent } from "../GridsDesktop/Colaboradores";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterColaboradores } from "../../Filters/Colaboradores";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ColaboradoresWindow from "./ColaboradoresWindow";

const ColaboradoresGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [colaboradores, setColaboradores] = useState<IColaboradores[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedColaboradores, setSelectedColaboradores] = useState<IColaboradores>(ColaboradoresEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterColaboradores | undefined | null>(null);

    const colaboradoresService = useMemo(() => {
      return new ColaboradoresService(
          new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchColaboradores = async (filtro?: FilterColaboradores | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await colaboradoresService.getList(filtro ?? {} as FilterColaboradores);
        setColaboradores(data);
      }
      else {
        const data = await colaboradoresService.getAll(filtro ?? {} as FilterColaboradores);
        setColaboradores(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchColaboradores(currFilter);
    }, [showInc]);
  
    const handleRowClick = (colaboradores: IColaboradores) => {
      if (isMobile) {
        router.push(`/pages/colaboradores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${colaboradores.id}`);
      } else {
        setSelectedColaboradores(colaboradores);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/colaboradores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedColaboradores(ColaboradoresEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchColaboradores(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const colaboradores = e.dataItem;		
        setDeleteId(colaboradores.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchColaboradores(currFilter);
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
           <ColaboradoresGridMobileComponent data={colaboradores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ColaboradoresGridDesktopComponent data={colaboradores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ColaboradoresWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedColaboradores={selectedColaboradores}>       
        </ColaboradoresWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ColaboradoresGrid;