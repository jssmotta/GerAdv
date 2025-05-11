// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IServicos } from "../../Interfaces/interface.Servicos";
import { ServicosService } from "../../Services/Servicos.service";
import { ServicosApi } from "../../Apis/ApiServicos";
import ServicosWindow from "./ServicosWindow";

interface ServicosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ServicosWindowId: React.FC<ServicosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const servicosService = useMemo(() => {
        return new ServicosService(
            new ServicosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IServicos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await servicosService.fetchServicosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ServicosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedServicos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ServicosWindowId;