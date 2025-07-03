import React from 'react';
import { render } from '@testing-library/react';
import OutrasPartesClienteIncContainer from '@/app/GerAdv_TS/OutrasPartesCliente/Components/OutrasPartesClienteIncContainer';
// OutrasPartesClienteIncContainer.test.tsx
// Mock do OutrasPartesClienteInc
jest.mock('@/app/GerAdv_TS/OutrasPartesCliente/Crud/Inc/OutrasPartesCliente', () => (props: any) => (
<div data-testid='outraspartescliente-inc-mock' {...props} />
));
describe('OutrasPartesClienteIncContainer', () => {
  it('deve renderizar OutrasPartesClienteInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OutrasPartesClienteIncContainer id={id} navigator={mockNavigator} />
  );
  const outraspartesclienteInc = getByTestId('outraspartescliente-inc-mock');
  expect(outraspartesclienteInc).toBeInTheDocument();
  expect(outraspartesclienteInc.getAttribute('id')).toBe(id.toString());

});
});