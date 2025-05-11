// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IClientesSocios } from "../../Interfaces/interface.ClientesSocios";
import { ClientesSociosService } from "../../Services/ClientesSocios.service";
import { ClientesSociosApi } from "../../Apis/ApiClientesSocios";
import ClientesSociosWindow from "./ClientesSociosWindow";

interface ClientesSociosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ClientesSociosWindowId: React.FC<ClientesSociosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const clientessociosService = useMemo(() => {
        return new ClientesSociosService(
            new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IClientesSocios | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await clientessociosService.fetchClientesSociosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ClientesSociosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedClientesSocios={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ClientesSociosWindowId;