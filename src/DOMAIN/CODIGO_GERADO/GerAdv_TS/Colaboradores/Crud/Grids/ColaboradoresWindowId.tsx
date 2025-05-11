// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IColaboradores } from "../../Interfaces/interface.Colaboradores";
import { ColaboradoresService } from "../../Services/Colaboradores.service";
import { ColaboradoresApi } from "../../Apis/ApiColaboradores";
import ColaboradoresWindow from "./ColaboradoresWindow";

interface ColaboradoresWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ColaboradoresWindowId: React.FC<ColaboradoresWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const colaboradoresService = useMemo(() => {
        return new ColaboradoresService(
            new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IColaboradores | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await colaboradoresService.fetchColaboradoresById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ColaboradoresWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedColaboradores={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ColaboradoresWindowId;