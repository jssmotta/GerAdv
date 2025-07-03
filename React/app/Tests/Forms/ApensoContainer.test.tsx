import React from 'react';
import { render } from '@testing-library/react';
import ApensoIncContainer from '@/app/GerAdv_TS/Apenso/Components/ApensoIncContainer';
// ApensoIncContainer.test.tsx
// Mock do ApensoInc
jest.mock('@/app/GerAdv_TS/Apenso/Crud/Inc/Apenso', () => (props: any) => (
<div data-testid='apenso-inc-mock' {...props} />
));
describe('ApensoIncContainer', () => {
  it('deve renderizar ApensoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ApensoIncContainer id={id} navigator={mockNavigator} />
  );
  const apensoInc = getByTestId('apenso-inc-mock');
  expect(apensoInc).toBeInTheDocument();
  expect(apensoInc.getAttribute('id')).toBe(id.toString());

});
});