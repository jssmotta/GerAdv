import React from 'react';
import { render } from '@testing-library/react';
import ClientesSociosIncContainer from '@/app/GerAdv_TS/ClientesSocios/Components/ClientesSociosIncContainer';
// ClientesSociosIncContainer.test.tsx
// Mock do ClientesSociosInc
jest.mock('@/app/GerAdv_TS/ClientesSocios/Crud/Inc/ClientesSocios', () => (props: any) => (
<div data-testid='clientessocios-inc-mock' {...props} />
));
describe('ClientesSociosIncContainer', () => {
  it('deve renderizar ClientesSociosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ClientesSociosIncContainer id={id} navigator={mockNavigator} />
  );
  const clientessociosInc = getByTestId('clientessocios-inc-mock');
  expect(clientessociosInc).toBeInTheDocument();
  expect(clientessociosInc.getAttribute('id')).toBe(id.toString());

});
});